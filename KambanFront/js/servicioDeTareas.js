const baseUrl = "https://localhost:7108/api/"

async function obtenerTareas() {
    const response = await fetch(baseUrl + "tareas")
    if (response.ok) {
        return response.json()
    }
}

async function agregarTareaAsync(tarea) {            
    const myHeaders = new Headers();
    myHeaders.append("accept", "*/*");
    myHeaders.append("Content-Type", "application/json");
    const raw = JSON.stringify(tarea)
    const requestOptions = {
        method: "POST",
        body: raw,
        headers: myHeaders
    }
    const response = await fetch(baseUrl + "Tareas", requestOptions)
    console.log(response)
    if (response.ok) {
        return response.json()
    } else {
        const errorData = await response.json(); // Obtenemos el cuerpo del error en formato JSON
        console.log("Error:", errorData); // Mostramos el error en consola
        throw new Error("Error en la solicitud: " + JSON.stringify(errorData));
    }
}

async function obtenerTareaPorId(tareaId) {
    const response = await fetch(baseUrl + "tareas/"+ tareaId)
    if (response.ok) {
        return response.json()
    }
}