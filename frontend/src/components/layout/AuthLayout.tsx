import { ReactNode } from "react";

interface AuthLayoutProps {
  children: ReactNode;
  backgroundImage?: string;
}

export const AuthLayout = ({ children, backgroundImage }: AuthLayoutProps) => {
  return (
    <div className="flex h-auto bg-gray-100">
      <div className="w-full lg:w-1/2 flex items-center justify-center px-6 bg-white overflow-auto">
        <div className="w-full max-w-lg">{children}</div>
      </div>

      <div className=" lg:block lg:w-1/2">
        <div
          className="w-full h-full min-h-screen bg-no-repeat bg-center bg-cover"
          style={{
            backgroundImage: `url(${backgroundImage})`,
            backgroundBlendMode: "overlay",
          }}
        >
          <div className="h-full flex items-center justify-center">
            <div className="text-white text-center">
              <h1 className="text-4xl font-bold mb-4">Library App</h1>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
