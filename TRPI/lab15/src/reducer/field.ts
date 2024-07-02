import {SET_CELL, CREATE_FIELD, GET_HINT} from "../actions/index";
import generatePuzzle from "../scripts/Generator";
import {adjustMatrix, Copy} from "../scripts/Checker";
import findAnswer from "../scripts/Solver";

export interface Field {
    field: number[][];
    correctField: number[][];
    errorState: number[][];
    isCorrect: boolean;
}

type FieldAction = {type: typeof CREATE_FIELD;} | 
                   {type: typeof GET_HINT} | 
                   {type: typeof SET_CELL; 
                    i: number, 
                    j:number, 
                    n:number };

export default function fieldReducer(state: Field = {field: Array(9).fill(null).map(() => Array(9).fill(0)),
                                     correctField: Array(9).fill(null).map(() => Array(9).fill(0)),
                                     errorState: Array(9).fill(null).map(() => Array(9).fill(0)),
                                     isCorrect:false},
                                     action: FieldAction): Field{

    if (action.type === CREATE_FIELD) {
        let field:number[][] = generatePuzzle();
        console.log(field);
        let correct:number[][] | null = findAnswer(field);
        console.log(correct);
        return {field: field, correctField: correct===null?Copy(state.correctField):correct, 
        errorState: adjustMatrix(state.correctField, field), isCorrect:true};
    } else if (action.type === SET_CELL) {
        let field: number[][] = Copy(state.field);
        if(field[action.i][action.j] !== action.n)
            field[action.i][action.j] = action.n;
        else
            field[action.i][action.j] = 0;
        let error:number[][] = adjustMatrix(state.correctField, field);
        return {
            field: field,
            correctField:Copy(state.correctField),
            errorState: error,
            isCorrect: !error.some(row => row.some(element => element < 0)),
        };
    } else if(action.type === GET_HINT){
        const newField: number[][] = Copy(state.field);

        for (let i = 0; i < newField.length; i++) {
            for (let j = 0; j < newField.length; j++) {
                if (newField[i][j] === 0) {
                    newField[i][j] = state.correctField[i][j];
                    return {
                        ...state,
                        field:newField
                    };
                }
            }
        }
        return state;

    } else {
        return state;
    }
}