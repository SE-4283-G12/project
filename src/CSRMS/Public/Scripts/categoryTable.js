const categories =
    [
        {
            categoryName: 'School',
            totalTask: 24,
            completedTask: 10
        },
        {
            categoryName: 'Home',
            totalTask: 44,
            completedTask: 31
        },
        {
            categoryName: 'Gym',
            totalTask: 4,
            completedTask: 2
        },
        {
            categoryName: 'Animals',
            totalTask: 50,
            completedTask: 11
        },
        {
            categoryName: 'Plants',
            totalTask: 5,
            completedTask: 0
        }].map(category => ({
            ...category,
            percentComplete: (category.completedTask / category.totalTask) * 100
        }));


let tableRowCount = document.getElementsByClassName('tableRowCount');
//tableRowCount[0].innerHTML = `(${task.length}) Tasks`;

let tableBody = document.getElementById('taskRows');

categories.sort((a, b) => {
    // Compare cateogry Names
    return a.categoryName.localeCompare(b.categoryName);
});

const mappedRecords = categories
    .map((task) => {

        return `<tr>
            <td >
                ${categories.categoryName}
            </td>
            <td>
                ${categories.precentComplete}
            </td>
        </tr>`;
    })

tableBody.innerHTML = mappedRecords.join('');
