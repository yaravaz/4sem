import React, {useState} from 'react';
import './App.css';
import Button from './components/Button';
import Counter from './components/Counter';

function App(): JSX.Element {

  const [count, setCount] = useState<number>(0);
  const [color, setColor] = useState<string>('black');
  
  let increase = (): void => {
    setCount(count + 1)
  }

  let reset = (): void =>{
    setCount(0)
  }

  const draw = () => {
    const newColor = color === 'red' ? 'black' : 'red';
    setColor(newColor);
  };


  return (
    <div className='container'>
      <div className="counter" >
        <Counter count={count} color={color}/>
      </div>
      <div className="btns">
        <Button title="increase" func={increase} disabled={count>=5}/>
        <Button title="reset" func={reset} disabled = {count === 0}/>
        <Button title="color" func={draw}/>
      </div>
    </div>
  );
}

export default App;
