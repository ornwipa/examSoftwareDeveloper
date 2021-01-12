import React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
import { Guid } from "guid-typescript";

interface FetchRecordDataState {
    empList: BloodWork[];
    loading: boolean;
}

export class BloodWork {
    Id: Guid = Guid.create();
    DateCreated: Date = new Date();
    ExamDate: Date = new Date();
    ResultsDate: Date = new Date();
    Description: string = "";
    Hemoglobin: number = 0;
    Hematocrit: number = 0;
    WhiteBloodCellCount: number = 0;
    RedBloodCellCount: number = 0;
} 

export class FetchRecord extends React.Component<RouteComponentProps<{}>, FetchRecordDataState> {
    constructor(props: any) {
        super(props);
        this.state = { empList: [], loading: true };
        fetch('api/BloodWork/Index')
        .then(response => response.json() as Promise<BloodWork[]>)
        .then(data => {
            this.setState({ empList: data, loading: false });
        });
        this.handleEdit = this.handleEdit.bind(this);
    }

    private handleEdit(Id: Guid) {
        this.props.history.push("BloodWork/EditRecord" + Id)
    }

    public render() {
        let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : this.renderBloodWorkTable(this.state.empList);
        return <div>
            <h1>Your Blood Work</h1>
            <p>
                <Link to="/AddRecord">Create New Blood Work</Link>
            </p>
        </div>
    }

    private renderBloodWorkTable(empList: BloodWork[]) {
        return <table className="table">
            <thead>
                <tr>
                    <th><b>Created Date</b></th>
                    <th><b>Exam Date</b></th>
                    <th><b>Description</b></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                { empList.map(emp =>
                <tr key = { emp.Id.toString() }>
                    <td>{ emp.DateCreated }</td>
                    <td>{ emp.ExamDate }</td>
                    <td>{ emp.Description }</td>
                    <td>
                        <a className="action" onClick={(Id) => this.handleEdit(emp.Id)}><b>Edit</b></a>
                    </td>
                </tr>
                )}
            </tbody>
        </table>
    }
}
