import { httpClient } from "../http-services/axios/httpClient";
import { ENDPOINT_API } from "../http-services/axios/config";
import {
  AuthResponse,
  LoginRequest,
  RegisterRequest,
} from "../types/auth.types";

export const login = async (data: LoginRequest): Promise<AuthResponse> => {
  const response = await httpClient.post<AuthResponse>(
    ENDPOINT_API.auth.login,
    data
  );
  if (response.data.token) {
    localStorage.setItem("token", response.data.token);
  }
  return response.data;
};

export const register = async (
  data: RegisterRequest
): Promise<AuthResponse> => {
  const response = await httpClient.post<AuthResponse>(
    ENDPOINT_API.auth.register,
    data
  );
  return response.data;
};

export const logout = () => {
  localStorage.removeItem("token");
  window.location.href = "/login";
};
