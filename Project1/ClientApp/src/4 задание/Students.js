import React from 'react';
import { Table } from 'antd';
import '../App.css';
import { inject, observer } from 'mobx-react';
const columns = [
  {
    title: 'id',
    dataIndex: 'id',
    key: 'id',
  },
  {
    title: 'name',
    dataIndex: 'name',
    key: 'name',
  },
  {
    title: 'username',
    dataIndex: 'username',
    key: 'username',
  },
];
@inject('NumberCoursWork')
@observer
class Students extends React.Component {
  constructor() {
    super();
    this.columns = [];
  }
  state = {
    todos: [],
  };
  componentDidMount = async () => {
      this.postData().then((data) => {
      this.setState({
        todos: data,
      });
    });
  };
  switch = (value) => {
    this.props.switchId(value);
  };
  async postData() {
    const response = await fetch('Students/SimplePost', {
      method: 'POST',
    });
    return await response.json();
  }
  render() {
    return (
      <div className='students'>
        <Table
          onRow={(record, rowIndex) => {
            return {
              onClick: (event) => {
                this.switch(record.id);
                this.props.NumberCoursWork.changeCount(record.id);
              }, // click row
              onDoubleClick: (event) => {}, // double click row
              onContextMenu: (event) => {}, // right button click row
              onMouseEnter: (event) => {}, // mouse enter row
              onMouseLeave: (event) => {}, // mouse leave row
              style: {
                background:
                  this.props.NumberCoursWork.count.indexOf(rowIndex + 1) != -1
                    ? 'gray'
                    : 'white',
              },
            };
          }}
          dataSource={this.state.todos}
          columns={columns}
        />
        ;
      </div>
    );
  }
}
export default Students;
