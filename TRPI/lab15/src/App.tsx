import React from 'react';
import Sudoku from "./components/Sudoku";
import NumbersPanel from "./сontainer/NumbersPanel";
import SudokuContainer from "./сontainer/SudokuContainer";
import GenerateButton from "./сontainer/GenerateButton";
import HintButton from "./сontainer/HintButton";

function App() {
  return (
    <div className="App">
        <SudokuContainer/>
        <div className="ButtonContainer">
            <GenerateButton text="Новая игра" name="gameButton"/>
            <HintButton text="Подсказка" name="gameButton"/>
        </div>
        <NumbersPanel />
    </div>
  );
}
export default App;
