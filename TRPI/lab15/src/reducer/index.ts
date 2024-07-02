import { combineReducers } from 'redux'
import fieldReducer, {Field} from "./field";
import numberReducer, {Numbers} from "./number";

export interface State {
    field: Field;
    number: Numbers;
}

export const rootReducer = combineReducers({
    field: fieldReducer,
    number: numberReducer,
})