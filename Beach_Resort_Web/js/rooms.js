async function loadRooms() {
    const res = await fetch(`${API_BASE}/rooms`);
    const data = await res.json();

    let table = document.getElementById("roomsTable");
    table.innerHTML = "";

    data.forEach(r => {
        table.innerHTML += `
        <tr>
            <td>${r.id}</td>
            <td>${r.roomType}</td>
            <td>${r.price}</td>
        </tr>`;
    });
}

async function addRoom() {
    const room = {
        roomType: document.getElementById("roomType").value,
        price: document.getElementById("price").value
    };

    await fetch(`${API_BASE}/rooms`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(room)
    });

    loadRooms();
}