
const task = [
    {
        task: 'Complete FrontEnd development',
        Priority: 'High',
        Location: 'Home',
        Category: 'School',
        Time: '8:00 AM'
    },
    {
        task: 'Go To Gym',
        Priority: 'Medium',
        Location: 'LandRush',
        Category: 'Fitness',
        Time: '7:00 AM'
    },
    {
        task: 'Poop Scoop Backyard',
        Priority: 'Low',
        Location: 'Home',
        Category: 'Home',
        Time: '5:00 PM'
    },
    {
        task: 'Team Meeting',
        Priority: 'Medium',
        Location: 'Home',
        Category: 'School',
        Time: '3:00 PM'
    },
    {
        task: 'Go get Groceries',
        Priority: 'High',
        Location: 'Crest',
        Category: 'Home',
        Time: '10:00 AM'
    }]

let tableRowCount = document.getElementsByClassName('table-row-count');
tableRowCount[0].innerHTML = `(${task.length}) Tasks`;

let tableBody = document.getElementById('task-rows');

const priorityOrder = { High: 1, Medium: 2, Low: 3 };


task.sort((a, b) => {
    // Compare priority first
    const priorityComparison = priorityOrder[a.Priority] - priorityOrder[b.Priority];

    return priorityComparison;
});

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


