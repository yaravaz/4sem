import React, {useState} from 'react';
import NumbersPanel from "./Components/NumbersPanel";
import Sudoku from "./Components/Sudoku";

function App() {

    const [chosenNumber, setChosenNumber] = useState<number>(1);
    
  return (
    <div className="App">
        <Sudoku chosenNumber={chosenNumber} />
        <NumbersPanel chosenNumber={chosenNumber} fun={setChosenNumber} />
    </div>
  );
}

export default App;
  