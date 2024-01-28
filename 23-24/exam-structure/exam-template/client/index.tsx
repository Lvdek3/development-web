import ReactDOM from 'react-dom'
import React, { useState } from 'react';

class CounterFist extends React.Component<{ initialValue: number, increment: number }, { count: number }> {
  constructor(props: { initialValue: number, increment: number }) {
    super(props);
    this.state = {
      count: props.initialValue
    };
  }

  render() {
    return (
      <div>
        <p>Count: {this.state.count}</p>
        <button onClick={this.incrementCount}>Increment</button>
      </div>
    );
  }

  incrementCount = () => {
    this.setState(prevState => ({
      count: prevState.count + this.props.increment
    }));
  }
}

ReactDOM.render(<CounterFist initialValue={0} increment={1} />, document.getElementById('root'));



const Counter: React.FC<{ initialValue: number, increment: number }> = (props) => {
  const [count, setCount] = useState(props.initialValue);

  const incrementCount = () => {
    setCount(count + props.increment);
  }

  return (
    <div>
      <p>Count: {count}</p>
      <button onClick={incrementCount}>Increment</button>
    </div>
  );
}

export default Counter;

