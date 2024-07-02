import {Dispatch} from "redux";
import {Action, getHint} from "../actions";
import {connect} from "react-redux";
import button from "../components/Button";


const mapDispatchToProps = (dispatch : Dispatch<Action>) => ({
    fun: () => dispatch(getHint())
});
export default connect(null, mapDispatchToProps)(button);

