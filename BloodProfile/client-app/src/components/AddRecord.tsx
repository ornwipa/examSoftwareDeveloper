import React from 'react';
import { RouteComponentProps } from 'react-router';
import { BloodWork } from './FetchRecord';

interface AddRecordDataState {
    title: string;
    loading: boolean;
    empData: BloodWork;
}

export class AddRecord extends React.Component<RouteComponentProps<{}>, AddRecordDataState> {
    constructor(props: any) {
        super(props);
        this.state = { title: "", loading: true, empData: new BloodWork() };
        var recordid = this.props.match.params["Id"];
        if (recordid) {
            fetch('api/bloodwork/Details/' + recordid)
            .then(response => response.json() as Promise<BloodWork>)
            .then(data => {
                this.setState({ title: "Edit", loading: false, empData: data })
            })
        }
        else {
            this.state = { title: "Create", loading: false, empData: new BloodWork() }
        }        
        this.handleCancel = this.handleCancel.bind(this);
        this.handleSave = this.handleSave.bind(this);
    }

    private handleCancel(event: any) {
        event.preventDefault();
        this.props.history.push("bloodwork");
    }

    private handleSave(event: any) {
        event.preventDefault();
        const data = new FormData(event.target);
        if (this.state.empData.Id) {
            fetch("api/bloodwork/EditRecord", {
                method: 'PUT',
                body: data,
            }).then((response) => response.json())
            .then((responseJson) => {
                this.props.history.push("bloodwork");
            })
        }
        else {
            fetch("api/bloodwork/AddRecord", {
                method: 'POST',
                body: data,
            }).then((response) => response.json())
            .then((responseJson) => {
                this.props.history.push("bloodwork");
            })
        }
    }

    public render() {
        let contents = this.state.loading
        ? <p><em>Loadding...</em></p>
        : this.renderCreateForm();
        return <div>
            <h1>{this.state.title}</h1>
            <h2>Blood Work Record</h2>
            <hr />
            { contents }
        </div>
    }
        
    private renderCreateForm() {
        return (
            <form onSubmit={this.handleSave}>
                
            </form>
        )
    }
}
