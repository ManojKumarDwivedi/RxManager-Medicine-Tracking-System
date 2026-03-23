

const medicineApi = "/api/medicine";
const salesApi = "/api/sales";

// Load Medicines
async function loadMedicines() {
    const search = document.getElementById("search").value.toLowerCase();

    const res = await fetch(medicineApi);
    let data = await res.json();

    if (search) {
        data = data.filter(m => m.fullName.toLowerCase().includes(search));
    }

    const table = document.getElementById("medicineTable");
    table.innerHTML = "";

    data.forEach(m => {
        const tr = document.createElement("tr");

        const expiry = new Date(m.expiryDate);
        const today = new Date();
        const diffDays = (expiry - today) / (1000 * 60 * 60 * 24);

        // Color rules
        if (diffDays < 30) tr.classList.add("red");
        else if (m.quantity < 10) tr.classList.add("yellow");

        tr.innerHTML = `
            <td>${m.fullName}</td>
            <td>${m.brand}</td>
            <td>${expiry.toDateString()}</td>
            <td>${m.quantity}</td>
            <td>${m.price.toFixed(2)}</td>
            <td>
                <button onclick="sellMedicine(${m.id})">Sell</button>
            </td>
        `;

        table.appendChild(tr);
    });
}

async function addMedicine() {
    const name = document.getElementById("name").value.trim();
    const brand = document.getElementById("brand").value.trim();
    const quantity = document.getElementById("quantity").value;
    const price = document.getElementById("price").value;
    const expiry = document.getElementById("expiry").value;

    // Validation
    if (!name) {
        alert("Medicine name is required");
        return;
    }

    if (!brand) {
        alert("Brand is required");
        return;
    }

    if (!quantity || quantity < 0) {
        alert("Enter valid quantity");
        return;
    }

    if (!price || price <= 0) {
        alert("Enter valid price");
        return;
    }

    if (!expiry) {
        alert("Expiry date is required");
        return;
    }

    // Create object
    const medicine = {
        fullName: name,
        brand: brand,
        quantity: parseInt(quantity),
        price: parseFloat(price),
        expiryDate: expiry,
        notes: ""
    };

    await fetch("/api/medicine", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(medicine)
    });

    alert("Medicine added successfully!");

    // Clear form
    document.getElementById("name").value = "";
    document.getElementById("brand").value = "";
    document.getElementById("quantity").value = "";
    document.getElementById("price").value = "";
    document.getElementById("expiry").value = "";

    loadMedicines();
}

// Sell Medicine
async function sellMedicine(id) {
    const qty = prompt("Enter quantity to sell:");

    if (!qty || qty <= 0) return;

    await fetch(salesApi, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            medicineId: id,
            quantitySold: parseInt(qty)
        })
    });

    alert("Sale recorded!");

    loadMedicines();
}

// Initial load
loadMedicines();

async function loadSales() {

    // Fetch both APIs
    const salesRes = await fetch("/api/sales");
    const sales = await salesRes.json();

    const medRes = await fetch("/api/medicine");
    const medicines = await medRes.json();

    const table = document.getElementById("salesTable");
    table.innerHTML = "";

    sales.forEach(s => {

        // Find medicine name
        const med = medicines.find(m => m.id === s.medicineId);

        const tr = document.createElement("tr");

        const date = new Date(s.saleDate);

        tr.innerHTML = `
            <td>${med ? med.fullName : "Unknown"}</td>
            <td>${s.quantitySold}</td>
            <td>${date.toLocaleString()}</td>
        `;

        table.appendChild(tr);
    });
}