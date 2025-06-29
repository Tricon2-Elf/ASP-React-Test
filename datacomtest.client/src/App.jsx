import { useState } from 'react';
import './App.css';

function App() {
    const [name, setName] = useState('');
    const [demographicData, setDemographicData] = useState();

    const contents = demographicData === undefined
        ? <p><em>Enter a name and press Estimate</em></p>
        : <div>
                Gender: {demographicData.gender}<br/>
                Age: {demographicData.age}<br/>
                Country: {demographicData.country_name}
            </div>

    return (
        <div>
            <h1 id="tableLabel">Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            <input
                type="text"
                value={name}
                onChange={e => setName(e.target.value)}
                placeholder="Enter Name"
            />
            <button onClick={populateDemographicData}>Estimate</button>
            {contents}
        </div>
    );
    
    async function populateDemographicData() {
        const response = await fetch(`allify?name=${encodeURIComponent(name)}`);
        if (response.ok) {
            const data = await response.json();
            if (data.age == 0)
                data.age = "Not in dataset"
            if (data.gender == "")
                data.gender = "Not in dataset"
            if (data.country_name == "")
                data.country_name = "Not in dataset"
            setDemographicData(data);
        }
    }
}

export default App;