
// src/service/AdminService.js

export class AdminService {
    // --- User Management ---
    getUsers() {
        return fetch('/demo/data/admin_data/users.json', { headers: { 'Cache-Control': 'no-cache' } })
            .then((res) => res.json());
    }

    // In a real app, you'd have methods like:
    // createUser(user) { ... }
    // updateUser(user) { ... }
    // deleteUser(userId) { ... }

    // --- Role Management ---
    getRoles() {
        return fetch('/demo/data/admin_data/roles.json', { headers: { 'Cache-Control': 'no-cache' } })
            .then((res) => res.json());
    }

    createRole(role) {
        console.log('Simulating createRole:', role);
        // In a real app, this would be a POST request.
        // Here, we'll just return a promise that resolves with the role,
        // maybe with a new ID assigned.
        return Promise.resolve({ ...role, id: `new_${Math.random()}` });
    }

    updateRole(role) {
        console.log('Simulating updateRole:', role);
        // In a real app, this would be a PUT/PATCH request.
        return Promise.resolve(role);
    }

    deleteRole(roleId) {
        console.log('Simulating deleteRole:', roleId);
        // In a real app, this would be a DELETE request.
        return Promise.resolve({ success: true });
    }

    // --- Permission Management ---
    getPermissions() {
        return fetch('/demo/data/admin_data/permissions.json', { headers: { 'Cache-Control': 'no-cache' } })
            .then((res) => res.json());
    }
}
