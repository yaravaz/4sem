import React from "react";
import './Card.css';
import {Link} from 'react-router-dom';

interface CardProps{
    id:number;
    title: string;
    image: string;
    category: string;
    year: number;
}

let Card : React.FC<CardProps> = ({id, title, image, category, year}) => {
    
    return(
        <div className="card" key={id}>
            <img src={image} alt={title}/>
            <div className="cardInfo">
                <h3>{title}</h3>
                <p>
                    <Link to={"/" + category}>{category}</Link>
                </p>
                <p>{year}</p>
            </div>
        </div>
    )
}

export default Card;