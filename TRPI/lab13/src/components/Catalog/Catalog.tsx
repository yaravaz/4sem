import React, {useState} from 'react'
import Search from '../Search/Search'
import Card from '../Card/Card'
import "./Catalog.css"


let Category = () =>{
    let [movies, setMovies] = useState<any[]>([]);

    let searchMovies= async (name: string, category: string) => {
        try{
            let url = `http://www.omdbapi.com/?s=${name}&apikey=4c8ca427`;
            if(category !== 'all'){
                url += `&type=${category}`;
            }
            const response = await fetch(url);
            const data = await response.json();
            setMovies(data.Search || []);
        }catch (error){
            console.error('Error: ',  error)
        }
    };

    return(
        <div className='container'>
            <div className='searchBar'>
                <Search onSearch={searchMovies}/>
            </div>
            <div className='catalog'>
                {movies.length === 0 ? (<p className='null'>Нет таких</p>) : (
                    movies.map((movie:any)=>(
                        <Card key={movie.imdbID}
                              id={movie.imdbID}
                              title={movie.Title}
                              year={movie.Year}
                              category={movie.Type}
                              image={movie.Poster}/>
                    ))
                )}
            </div>
        </div>
    )
}

export default Category;