function login() {
    const user = document.getElementById("username").value;
    const pass = document.getElementById("password").value;

    if (user === "admin" && pass === "admin") {
        localStorage.setItem("role", "admin");
        window.location.href = "dashboard.html";
    }
    else if (user === "staff" && pass === "staff") {
        localStorage.setItem("role", "staff");
        window.location.href = "dashboard.html";
    }
    else {
        alert("Invalid login");
    }
}