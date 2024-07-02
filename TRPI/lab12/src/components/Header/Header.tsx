import React from 'react'
import {Link} from 'react-router-dom'
import "./Header.css"

let Header : React.FC = () =>{
    return(
        <header>
            <nav>
                <ul>
                    <li>
                        <Link to="/">Все</Link>
                    </li>
                    <li>
                        <Link to="/movies">Фильмы</Link>
                    </li>
                    <li>
                        <Link to="/series">Сериалы</Link>
                    </li>
                    <li>
                        <Link to="/cartoons">Мультфильмы</Link>
                    </li>
                </ul>
            </nav>
        </header>
    )
}

export default Header;