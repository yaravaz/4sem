const initialState = [];

const todos = (state = initialState, action) => {
  switch (action.type) {
    case 'ADD_TODO':
      return [
        ...state,
        {
          id: action.id,
          text: action.text,
          completed: false,
        },
      ];
    case 'TOGGLE_TODO':
      return state.map((todo) =>
        todo.id === action.id
          ? { ...todo, completed: !todo.completed }
          : todo
      );
    case 'SEARCH_TODO':
      return state.map((todo) => {
        if (todo.text.includes(action.text)) {
          return { ...todo, finded: true };
        } else {
          return { ...todo, finded: false };
        }
      });
    default:
      return state;
  }
};

export default todos;