import React from "react";
import search from './SearchBar.module.css';

interface SearchBarProps {
    filterText: string;
    inStockOnly: boolean;
    onFilterTextChange: (text: string) => void;
    onInStockChange: (checked: boolean) => void;
    onNewValueChange: (newValue: string) => void;
  }

const SearchBar: React.FC<SearchBarProps> = ({filterText, inStockOnly, onFilterTextChange, onInStockChange, onNewValueChange}) => {
    const handleFilterTextChange = (e: any) => {
      onFilterTextChange(e.target.value);
    };
  
    const handleInStockChange = (e: any) => {
      onInStockChange(e.target.checked);
    };
    const handleNewValueChange = (e: any) => {
      onNewValueChange(e.target.value);
    };
  
    return (
      <form>
        <input className={search.search}
          type="text"
          placeholder="Search..."
          value={filterText}
          onChange={handleFilterTextChange}
        />
        <p  className={search.box}>
          <input
            type="checkbox"
            checked={inStockOnly}
            onChange={handleInStockChange}
          />
          {' '}
          Only show products in stock
        </p>
        <input
          className={search.search}
          type="text"
          placeholder="Новый элемент"
          onChange={handleNewValueChange}
        />
      </form>
    );
}

export default SearchBar