import React from 'react';
import './App.css';
import PRODUCTS from './state';
import FilterableProductTable from './components/FilterableProductTable/FilterableProductTable';

function App() {
  return <FilterableProductTable products={PRODUCTS} />
}

export default App;
