import React from 'react'
import MOVIES from '../../movies'
import Card from '../Card/Card'
import "./Catalog.css"

interface CatalogProps{
    category?: string;
}

let Category : React.FC<CatalogProps> = ({category = 'all'}) =>{
    let filtered = category === 'all' ? MOVIES : MOVIES.filter((movie:any) => movie.category === category);

    return(
        <div className='catalog'>
            {filtered.map((movie:any)=> (
                <Card id = {movie.id}
                      title = {movie.title}
                      image = {movie.image}
                      category = {movie.category}
                      year = {movie.year}/>
            ))}
        </div>
    )
}

export default Category;