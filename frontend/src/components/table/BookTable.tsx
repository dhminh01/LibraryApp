import React from "react";
import { BookDto } from "../../types/book.types";

interface BookTableProps {
  books: BookDto[];
  selectedBookIds: string[];
  toggleSelectBook: (bookId: string) => void;
}

const BookTable: React.FC<BookTableProps> = ({
  books,
  selectedBookIds,
  toggleSelectBook,
}) => {
  return (
    <div className="overflow-x-auto mb-10">
      <table className="min-w-full bg-white shadow-md rounded-lg overflow-hidden">
        <thead className="bg-indigo-400">
          <tr>
            <th className="px-4 py-3 text-left text-white">Select</th>
            <th className="px-4 py-3 text-left text-white">Title</th>
            <th className="px-4 py-3 text-left text-white">Author</th>
            <th className="px-4 py-3 text-left text-white">Category</th>
            <th className="px-4 py-3 text-left text-white">Available</th>
          </tr>
        </thead>
        <tbody>
          {books.map((book) => (
            <tr
              key={book.id}
              className="odd:bg-white even:bg-gray-50 hover:bg-gray-100"
            >
              <td className="px-4 py-3">
                <input
                  type="checkbox"
                  className="h-5 w-5"
                  checked={selectedBookIds.includes(book.id)}
                  onChange={() => toggleSelectBook(book.id)}
                  disabled={
                    !selectedBookIds.includes(book.id) &&
                    selectedBookIds.length >= 5
                  }
                />
              </td>
              <td className="px-4 py-3">{book.title}</td>
              <td className="px-4 py-3">{book.author}</td>
              <td className="px-4 py-3">{book.categoryName ?? "N/A"}</td>
              <td className="px-4 py-3">
                <span
                  className={`px-2 py-1 rounded font-semibold ${
                    book.availableCopies === 0 ? "bg-red-300" : "bg-green-300"
                  }`}
                >
                  {book.availableCopies} available
                </span>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default BookTable;
