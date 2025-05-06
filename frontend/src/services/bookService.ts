import { ENDPOINT_API } from "../http-services/axios/config";
import { httpClient } from "../http-services/axios/httpClient";
import { BookDto, CreateBookDto, UpdateBookDto } from "../types/book.types";

export const getAllBooks = async (): Promise<BookDto[]> => {
  const response = await httpClient.get<BookDto[]>(ENDPOINT_API.books.getAll);
  return response.data;
};

export const getBookById = async (id: string): Promise<BookDto> => {
  const response = await httpClient.get<BookDto>(
    ENDPOINT_API.books.getById.replace("{id}", id)
  );
  return response.data;
};

export const createBook = async (
  data: CreateBookDto
): Promise<CreateBookDto> => {
  const response = await httpClient.post<CreateBookDto>(
    ENDPOINT_API.books.create,
    data
  );
  return response.data;
};

export const updateBook = async (
  id: string,
  data: UpdateBookDto
): Promise<UpdateBookDto> => {
  const response = await httpClient.put<UpdateBookDto>(
    ENDPOINT_API.books.update.replace("{id}", id),
    data
  );
  return response.data;
};

export const deleteBook = async (id: string): Promise<void> => {
  await httpClient.delete(ENDPOINT_API.books.delete.replace("{id}", id));
};
