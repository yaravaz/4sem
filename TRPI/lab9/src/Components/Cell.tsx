import React from "react";

interface CellProps{
    number:number,
    stateNumber:number,
    fun ?:()=>void
}

let Cell:React.FC<CellProps> = (props:CellProps) =>{
    const color = {backgroundColor: props.stateNumber < 0 ? 'red' : 'transparent'}
    let n = props.number % 10;
    return (
        <div style={color} onClick={Math.abs(props.stateNumber) !== 2 ? props.fun: ()=>{}}
             className="cell">{n !== 0 && Math.abs(n)}</div>
    )
}
export default Cell;