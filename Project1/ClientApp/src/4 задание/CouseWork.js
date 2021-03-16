import React from 'react';
import { Table } from 'antd';
const columns = [
  {
    title: 'id',
    dataIndex: 'id',
    key: 'id',
  },
  {
    title: 'title',
    dataIndex: 'title',
    key: 'title',
  },
  {
    title: 'body',
    dataIndex: 'body',
    key: 'body',
  },
];
class CouseWork extends React.Component {
  state = {
    todos: [],
  };
  componentDidMount = async () => {
    this.postData(this.props.id).then((data) => {
      this.setState({
        todos: data,
      });
    });
  };
  async postData(data) {
    const response = await fetch('Students/GetCouseWord', {
      method: 'POST',
      body: JSON.stringify(data),
    });
    return await response.json();
  }
  render() {
    return (
      <div className='students'>
        <Table dataSource={this.state.todos} columns={columns} />;
      </div>
    );
  }
}
export default CouseWork;
