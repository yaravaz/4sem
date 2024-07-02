import React, {useState} from 'react'
import "./Search.css"

interface SearchProps{
    onSearch: (name: string, category: string) => void
}

let Search : React.FC<SearchProps> = ({onSearch}) =>{
    let [name, setName] = useState('');
    let [category, setCategory] = useState('all');

    let handleSearch = () => {
        let currName = name.trim();
        onSearch(currName, category);
    }

    return(
        <div className='search'>
            <div className='searchBar'>
                <input type='text' value={name} onChange={(e) => setName(e.target.value)} placeholder='Введите название'/>
                <button onClick={handleSearch}>Искать</button>
            </div>
            <div>
                <label>
                    <input type='radio' value='all' checked={category === 'all'} onChange={() => setCategory('all')}/> 
                    Все
                </label>
                <label>
                    <input type='radio' value='movie' checked={category === 'movie'} onChange={() => setCategory('movie')}/> 
                    Только фильмы
                </label>
                <label>
                    <input type='radio' value='series' checked={category === 'series'} onChange={() => setCategory('series')}/> 
                    Только сериалы
                </label>
            </div>
        </div>
    )
}

export default Search;