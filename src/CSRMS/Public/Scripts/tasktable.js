
const task = [
    {
        task: 'Complete FrontEnd development', 
        Priority: 'High',
        Location: 'Home',
        Category: 'School'
    },
    {
        task: 'Go To Gym',
        Priority: 'Medium',
        Location: 'LandRush',
        Category: 'Fitness'
    },
    {
        task: 'Poop Scoop Backyard',
        Priority: 'Low',
        Location: 'Home',
        Category: 'Home'
    },
    {
        task: 'Team Meeting',
        Priority: 'Medium',
        Location: 'Home',
        Category: 'School'
    },
    {
        task: 'Go get Groceries',
        Priority: 'High',
        Location: 'Crest',
        Category: 'Home'
    },

]

let tabeRowCount = document.getElementByClassName('table-row-count');
tableRowCount[0].innerHTML = `(${task.length}) Tasks`;

let tableBody = document.getElementById('task-rows');



const mappedRecords = task
    .map((task) => {

        return `<tr>
            <td class="task-name">
                ${task.task}
            </td>
            <td>
                ${task.Priority}
            </td>
            <td>
                ${task.Location}
            </td>
            <td>
                ${task.Category}
            </td>
        </tr>`; 
    })

tableBody.innerHTML = mappedRecords.join('');


