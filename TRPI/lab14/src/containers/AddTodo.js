import React from 'react';
import { connect } from 'react-redux';
import { addTodo } from '../actions';
import './AddTodo.css';

const AddTodo = ({ dispatch }) => {
  let input;

  return (
    <div className='textTodo'>
      <form
        onSubmit={(e) => {
          e.preventDefault();
          if (!input.value.trim()) {
            return;
          }
          dispatch(addTodo(input.value));
          input.value = '';
        }}
      >
        <input className='bar' ref={(node) => (input = node)} />
        <button className='add' type="submit">Add Todo</button>
      </form>
    </div>
  );
};

export default connect()(AddTodo);