import React, {useEffect, useState} from 'react';
import Cell from "./Сell";
import {Field} from "../reducer/field";

interface SudokuProps{
    field:Field,
    n:number,
    isCorrect:boolean,
    changeNumber:(i:number, j:number, n:number) => void
}

let Sudoku:React.FC<SudokuProps> = (props:SudokuProps) => {
    const [back, setback] = useState("transparent")
    useEffect(() => {
        props.isCorrect? setback("yellow") : setback("transparent")

        setTimeout(
        () => {
                setback("transparent")
        }, 500
        )
    }, [props.isCorrect])

    return(<div  className="Container">
        <div style={{backgroundColor: back} } className="sudokuField">
            {Array.from({length: 9}, (_, i) => i).map((i) =>
                Array.from({length: 9}, (_, j) => j).map((j) =>
                    <Cell key={`${i}-${j}`} fun={()=>props.changeNumber(i, j, props.n)} stateNumber={props.field.errorState[i][j]} number={props.field.field[i][j]}/>
                )
            )}
        </div>
    </div>)
}


export default Sudoku;