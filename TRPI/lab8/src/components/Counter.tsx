import React from "react"

interface CounterProps{
    count: number;
    color: string
}

const Counter: React.FC<CounterProps> = (props: CounterProps) =>{
    const style = {
        color: props.color
    };

    return <p style={style}>{props.count}</p>
}

export default Counter;