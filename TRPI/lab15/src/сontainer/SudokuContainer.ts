import {State} from "../reducer";
import {Dispatch} from "redux";
import {Action, changeCell} from "../actions";
import {connect} from "react-redux";
import Sudoku from "../components/Sudoku";
import {Field} from "../reducer/field";

const mapStateToProps = (state : State) : {field:Field, n:number, isCorrect:boolean} => ({
    field: state.field,
    n: state.number.n,
    isCorrect: state.field.isCorrect,
});

const mapDispatchToProps = (dispatch : Dispatch<Action>) => ({
    changeNumber: (i:number, j:number, n:number) =>
        dispatch(changeCell(i, j, n))
});
export default connect(mapStateToProps, mapDispatchToProps)(Sudoku);