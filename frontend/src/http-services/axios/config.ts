export const ROOT_API = {
  baseURL: "http://localhost:5184",
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
  },
};

export const ENDPOINT_API = {
  auth: {
    login: "/api/Auth/login",
    register: "/api/Auth/register",
  },

  users: {
    getById: "/api/User/GetById/{id}",
    getAll: "/api/User/GetAll",
    update: "/api/User/Update",
    delete: "/api/User/Delete/{id}",
  },

  books: {
    getAll: "/api/Book",
    getById: "/api/Book/GetById/{id}",
    create: "/api/Book/Create",
    update: "/api/Book/Update/{id}",
    delete: "/api/Book/Delete/{id}",
  },

  categories: {
    getAll: "/api/Category/GetAll",
    getById: "/api/Category/GetById/{id}",
    create: "/api/Category/Create",
    update: "/api/Category/Update/{id}",
    delete: "/api/Category/Delete/{id}",
  },

  borrowings: {
    borrow: "/api/Borrowing/Borrow",
    getAllRequests: "/api/Borrowing/admin/requests",
    updateStatus: "/api/Borrowing/admin/requests/{id}/status",
    getByUserId: "/api/Borrowing/User/{id}/requests",
    getByRequestId: "/api/RequestDetail/request/{requestId}",
  },

  admin: {
    dashboard: "/api/Dashboard/admin",
  },
};
