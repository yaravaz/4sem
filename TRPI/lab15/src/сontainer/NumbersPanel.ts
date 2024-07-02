import { connect } from 'react-redux'
import {Dispatch} from "redux";
import {Action, setNumber} from '../actions'
import {State} from "../reducer";
import Number from "../components/Number";

const mapStateToProps = (state : State) : {chosenNumber : number} => {
    return ({chosenNumber: state.number.n});
}
const mapDispatchToProps = (dispatch : Dispatch<Action>) => ({
    fun: (n:number) => dispatch(setNumber(n))
});
export default connect(mapStateToProps, mapDispatchToProps)(Number);

