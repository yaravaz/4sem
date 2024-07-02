const initialState = 'SHOW_ALL';

const visibilityFilter = (state = initialState, action) => {
  switch (action.type) {
    case 'SET_VISIBILITY_FILTER':
      return action.filter;
    case 'SEARCH_TODO':
      return action.filter;
    default:
      return state;
  }
};

export default visibilityFilter;