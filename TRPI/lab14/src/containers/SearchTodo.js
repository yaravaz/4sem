import React from 'react';
import { connect } from 'react-redux';
import { searchTodo, setVisibilityFilter, VisibilityFilters } from '../actions';
import './SearchTodo.css';

const SearchTodo = ({ dispatch }) => {
  let input;

  return (
    <div className='textTodo'>
      <form
        onSubmit={(e) => {
          e.preventDefault();
          if (!input.value.trim()) {
            dispatch(setVisibilityFilter(VisibilityFilters.SHOW_ALL));
          } else {
            dispatch(searchTodo(VisibilityFilters.SHOW_FINDED, input.value));
          }
          input.value = '';
        }}
      >
        <input className='newbar' ref={(node) => (input = node)} />
        <button className='search' type="submit">Search</button>
      </form>
    </div>
  );
};
export default connect()(SearchTodo);