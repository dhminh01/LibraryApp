export interface UserResponseDto {
  id: string;
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  phoneNumber: string;
  address: string;
  dateOfBirth: string;
  isActive: boolean;
  role: number;
}

export interface UserUpdateDto extends UserResponseDto {}
