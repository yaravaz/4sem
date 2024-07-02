import React, {MouseEventHandler} from "react"

interface ButtonProps{
    title: string;
    func: MouseEventHandler<HTMLButtonElement>;
    disabled?: boolean;
}

const Button: React.FC<ButtonProps> = (props: ButtonProps) =>{
    return(
        <button onClick ={props.func} disabled={props.disabled}>
            {props.title}
        </button>
    );
}

export default Button;