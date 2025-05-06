import AdminLayout from "../components/layout/AdminLayout";
import AppLayout from "../components/layout/AppLayout";
import PermissionRoute from "../components/PermissionRoute";
import ProtectedRoute from "../components/ProtectedRoute";
import AdminDashboard from "../pages/AdminDashboard";
import BookManagePage from "../pages/BookManagePage";
import BorrowRequestPage from "../pages/BorrowRequestPage";
import BorrowRequestsManagePage from "../pages/BorrowRequestsManagePage";
import CategoryManagePage from "../pages/CategoryManagePage";
import HomePage from "../pages/HomePage";
import LoginPage from "../pages/LoginPage";
import RegisterPage from "../pages/RegisterPage";
import UnauthorizedPage from "../pages/UnauthorizedPage";
import UserManagePage from "../pages/UserManagePage";

const pathname = {
  home: "/",
  login: "/login",
  register: "/register",
  borrowRequest: "/borrow-request",
  adminUser: "/admin/users",
  adminBook: "/admin/books",
  adminCategory: "/admin/categories",
  adminDashboard: "/admin/dashboard",
  adminRequest: "admin/requests",
  unauthorized: "/unauthorized",
};

export const AppRouters = [
  { path: pathname.login, element: <LoginPage /> },
  { path: pathname.register, element: <RegisterPage /> },
  { path: pathname.unauthorized, element: <UnauthorizedPage /> },
  {
    element: (
      <ProtectedRoute>
        <AppLayout />
      </ProtectedRoute>
    ),
    children: [
      { path: pathname.borrowRequest, element: <BorrowRequestPage /> },
      { path: pathname.home, element: <HomePage /> },
    ],
  },
  {
    element: (
      <ProtectedRoute>
        <PermissionRoute allowedRoles={["Admin"]}>
          <AdminLayout />
        </PermissionRoute>
      </ProtectedRoute>
    ),
    children: [
      { path: pathname.adminUser, element: <UserManagePage /> },
      { path: pathname.adminRequest, element: <BorrowRequestsManagePage /> },
      { path: pathname.adminDashboard, element: <AdminDashboard /> },
      { path: pathname.adminCategory, element: <CategoryManagePage /> },
      { path: pathname.adminBook, element: <BookManagePage /> },
    ],
  },
];
