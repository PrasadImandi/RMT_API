"use client";
import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Button } from "../ui/button";
import AdminSearchUserInput from "./admin-search-user-input";
import { useEffect, useState } from "react";
import { format } from "date-fns";
import { useRouter } from "next/navigation";
import api from "@/lib/axiosInstance";
import DeleteProject from "./delete-project";

interface RowType {
  iD: string;
  name: string;
  isActive: boolean;
  startDate: string;
  endDate: string;
}

const AdminTable = () => {
  const router = useRouter();
  const [data, setData] = useState<RowType[]>([]);
  const [searchTerm, setSearchTerm] = useState<string>("");

  useEffect(() => {
    const fetchProject = async () => {
      try {
        const response = await api.get("/Project");
        console.log(response.data);
        setData(response.data);
      } catch (error) {
        console.error("Error fetching current user:", error);
      }
    };
    fetchProject();
  },[])

  const handleEdit = (id: any) => {
    router.push(`/admin/manage-project/edit-project/${id}`);
  };

  const handleDeleteUser = async (id: string) => {
  
      // Update the local state to reflect the change
      setData((prevData) =>
        prevData.map((user) =>
          user.iD === id ? { ...user, status: "Inactive" } : user
        )
      );
      console.log(`User with ID ${id} has been set to not active.`);
  
  };

    const filteredData = data.filter((row) =>
        row.name?.toLowerCase().includes(searchTerm.toLowerCase())
  );


  if(data.length === 0) {
    return <p>Fetching data</p>
  }

  return (
    <>
      <div className="bg-white dark:bg-[#17171A] py-8 px-16 flex justify-between items-center rounded-sm">
        <p className="text-2xl font-normal">Project List</p>
        <AdminSearchUserInput onSearch={setSearchTerm} />
      </div>
      <Table className="px-16">
        <TableCaption>A list of Project</TableCaption>
        <TableHeader className="text-gray-600 bg-gray-300 dark:bg-gray-700">
          <TableRow className="hover:bg-transparent">
            <TableHead className="w-10">No</TableHead>
            <TableHead>Project Name</TableHead>
            <TableHead>Starting Date</TableHead>
            <TableHead>Ending Date</TableHead>
            <TableHead>Status</TableHead>
            <TableHead className="text-right">Action</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody className="dark:bg-inherit">
                  {filteredData.map((row: RowType, index) => (
                      <TableRow key={row.iD}>
                  <TableCell className="font-medium ">{index + 1}</TableCell>
                  <TableCell className="">{row.name}</TableCell>
              <TableCell>{format(new Date(row.startDate), "dd/MM/yyyy")}</TableCell>
                  <TableCell>{format(new Date(row.endDate), "dd/MM/yyyy")}</TableCell>
                  <TableCell>{row.isActive === true ? "Active" :"Inactive"}</TableCell>
                  <TableCell className="text-right flex gap-x-2 justify-end">
                      <DeleteProject id={row.iD} onDelete={handleDeleteUser} type='project' disabled={row.isActive === false} />
                <Button
                  className=" bg-blue-500"
                          variant="default"
                          onClick={() => handleEdit(row.iD)}
                >
                  Edit
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </>
  );
};

export default AdminTable;
