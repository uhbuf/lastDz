import React from 'react';
import { Table } from 'antd';
const columns = [
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
    async newCouseWork(userId, title, body) {
        console.log(userId, title, body);
        let info = {
            userId,
            title,
            body
        };
        const response = await fetch('Students/NewCourseWork', {
            method: 'POST',
            body: JSON.stringify({ userId, title, body})
        });
        return await response.json();
    }
    newWork=()=> {
        this.newCouseWork(this.props.id, document.getElementById("value1").value, document.getElementById("value2").value).then(() => {
            this.postData(this.props.id).then((data) => {
                this.setState({
                    todos: data,
                });
            });
        })
    }
  render() {
      return (
            <>
              <div>
                  <input id="value1" />
                  <input id="value2" />
                  <button onClick={this.newWork}>NewWork</button>
              </div>
              <div className='students'>
                <Table dataSource={this.state.todos} columns={columns} />;
              </div>
            </>
    );
  }
}
export default CouseWork;
