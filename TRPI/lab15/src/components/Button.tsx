import React from "react";

interface ButtonProps{
    name:string,
    text:number|string,
    fun:()=>void
}

let Button:React.FC<ButtonProps> = (props:ButtonProps) => {
    return (<button className={props.name} onClick={props.fun}>{props.text}</button>)
}

export default Button;