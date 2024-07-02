import React, {useEffect, useState} from 'react';
import Cell from "../Components/Cell";
import Button from "./Button";
import generatePuzzle from "../Scripts/Generator";
import findAnswer from "../Scripts/Solver";
import { adjustMatrix, Copy } from "../Scripts/Checker";

let saveField:number[][] =new Array(9).fill(0).map(() => new Array(9).fill(0));

function Generate():number[][]{
    let Field = generatePuzzle()
    saveField = findAnswer(Field) as number[][];
    return Field;
}

interface SudokuProps{
    chosenNumber:number;
}

let Sudoku:React.FC<SudokuProps> = (props) => {
    const [isCorrect, setCorrect] = useState<Boolean>(false);
    const [field, setField] = useState<number[][]>(
        new Array(9).fill(0).map(() => new Array(9).fill(0))
    );
    const [fieldCellState, setFieldCellState] = useState<number[][]>(
        new Array(9).fill(0).map(() => new Array(9).fill(0))
    );

    const background = {backgroundColor:isCorrect?"yellow":"transparent"}
    const correctField=() => {setCorrect(true); setTimeout(()=>setCorrect(false), 400)}

    let fieldChange = (i:number, j:number, n?:number) => ():void => {
        const newField:number[][] = Copy(field);
        let number: number;
        if(n === undefined){
            number = props.chosenNumber;
        }
        else{
            number = n;
        }
        if(props.chosenNumber === newField[i][j])
            newField[i][j] = 0;
        else
            newField[i][j] = number;
        //setFieldCellState(fieldCheck(newField));
        setField(newField);
    }
    
    useEffect(() => {
        const handleKeyDown = (e:any) => {
            if(e.key === 'r' || e.key === 'к')
                fieldGenerate()
            if(e.key === 'i' || e.key === 'ш')
                fieldHint()
        };

        let fieldHint = () =>{
            const newField: number[][] = Copy(field);
    
            for (let i = 0; i < field.length; i++) {
                for (let j = 0; j < field[i].length; j++) {
                    if (field[i][j] === 0) {
                        fieldChange(i, j, saveField[i][j])();
                        return;
                    }
                }
            }
        }

        window.addEventListener('keydown', handleKeyDown);
        return () => {
            window.removeEventListener('keydown', handleKeyDown);
        };
    }, [field]);

    let fieldCheck = (m?:number[][])=>{
        let matrix:number[][];

        if(m === undefined)
            matrix= adjustMatrix(saveField, field);
        else
            matrix= adjustMatrix(saveField, m);

        if(!matrix.some(row => row.some(element => element < 0))) {
              correctField();
        }

        return matrix;
    }
    let fieldGenerate = () => {
        const generated:number[][] = Generate();
        setField(generated);
        setCorrect(false);
        let state :number[][]= adjustMatrix(saveField, generated);
        setFieldCellState(state);
    }
   
    return(<div className="Container">
        <div style={background} className="sudokuField">
            {Array.from({length: 9}, (_, i) => i).map((i) =>
                Array.from({length: 9}, (_, j) => j).map((j) =>
                    <Cell key={`${i}-${j}`} fun={fieldChange(i, j)} stateNumber={fieldCellState[i][j]} number={field[i][j]}/>
                )
            )}
        </div>
        <div className="ButtonContainer">
            <Button fun={fieldGenerate} text="Новая игра" name="gameButton"/>
            <Button fun={() => setFieldCellState(fieldCheck())} text="Проверить" name="gameButton"/>
        </div>
    </div>)
}


export default Sudoku;