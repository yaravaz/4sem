import React, {useEffect} from "react";
import Button from "./Button";

interface NumberPanelProps{
    chosenNumber:number,
    fun: React.Dispatch<React.SetStateAction<number>>
}

let NumbersPanel:React.FC<NumberPanelProps> = (props:NumberPanelProps) => {
    const numbers:number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    const Buttons:JSX.Element[] = numbers.map((number:number)=>
        <Button key={number} name="NumberButton" text={number} fun={()=>props.fun(number)}/>
    )

    useEffect(() => {
        const handleKeyDown = (e:any) => {
            if(e.key >= '1' && e.key <='9')
                props.fun(parseInt(e.key));
        };
        window.addEventListener('keydown', handleKeyDown);
        return () => {
            window.removeEventListener('keydown', handleKeyDown);
        };
    }, []);
    return <div className="Panel">
                <h2>{props.chosenNumber}</h2>
                {Buttons}
            </div>
}

export default NumbersPanel