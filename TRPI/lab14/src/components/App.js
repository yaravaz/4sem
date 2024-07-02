import React from 'react';
import Footer from './Footer';
import AddTodo from '../containers/AddTodo';
import VisibleTodoList from '../containers/VisibleTodoList';
import "./App.css";
import SearchTodo from '../containers/SearchTodo';

const App = () => (
  <div className='app'>
    <div>
      <AddTodo />
      <SearchTodo/>
    </div>
    <VisibleTodoList />
    <Footer />
  </div>
);

export default App;