import {Dispatch} from "redux";
import {Action, generateField} from "../actions/index";
import {connect} from "react-redux";
import button from "../components/Button";


const mapDispatchToProps = (dispatch : Dispatch<Action>) => ({
    fun: () => dispatch(generateField())
});
export default connect(null, mapDispatchToProps)(button);

