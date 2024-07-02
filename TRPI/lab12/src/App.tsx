import React from 'react';
import {BrowserRouter, Route, Routes} from 'react-router-dom';
import Header from './components/Header/Header';
import Catalog from './components/Catalog/Catalog';
import Footer from './components/Footer/Footer';
import './App.css';

let App : React.FC = () =>  {   
  return(
    <BrowserRouter>
      <div className="App">
        <Header/>
        <Routes>
          <Route path="/" element={<Catalog/>}/>
          <Route path="/movies" element={<Catalog category="movies"/>}/>
          <Route path="/series" element={<Catalog category="series"/>}/>
          <Route path="/cartoons" element={<Catalog category="cartoons"/>}/>
        </Routes>
        <Footer/>
      </div>
    </BrowserRouter>
  )
}

export default App;
