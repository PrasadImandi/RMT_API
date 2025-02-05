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
import { Switch } from "@/components/ui/switch"; // Import Switch

interface ProjectType {
  id: number;
  projectCode: string;
  startDate: string;
  endDate: string;
  isActive: boolean;
  name?: string | null;
  pmName?: string | null;
  rmName?: string | null;
}

const AdminTable = () => {
  const router = useRouter();
  const [data, setData] = useState<ProjectType[]>([]);
  const [searchTerm, setSearchTerm] = useState<string>("");
  const [showActiveProjects, setShowActiveProjects] = useState<boolean>(true); // Toggle for active/inactive projects

  useEffect(() => {
    const fetchProjects = async () => {
      try {
        const response = await api.get("/Project");
        console.log(response.data);
        setData(response.data);
      } catch (error) {
        console.error("Error fetching projects:", error);
      }
    };
    fetchProjects();
  }, []);

  const handleEdit = (id: number) => {
    router.push(`/admin/manage-project/edit-project/${id}`);
  };

  const handleDeactivateProject = async (id: number) => {
    setData((prevData) =>
      prevData.map((project) =>
        project.id === id ? { ...project, isActive: false } : project
      )
    );
    await api.patch("/Project", { id, isActive: false });
    console.log(`Project with ID ${id} has been deactivated.`);
  };

  const filteredData = data.filter((row) => {
    const matchesSearch =
      row.name?.toLowerCase().includes(searchTerm.toLowerCase()) ||
      row.pmName?.toLowerCase().includes(searchTerm.toLowerCase()) ||
      row.rmName?.toLowerCase().includes(searchTerm.toLowerCase());

    const matchesActiveFilter = showActiveProjects
      ? row.isActive
      : !row.isActive;

    return matchesSearch && matchesActiveFilter;
  });

  if (data.length === 0) {
    return <p>Fetching data...</p>;
  }

  return (
    <>
      <div className="bg-white dark:bg-[#17171A] py-8 px-16 flex justify-between items-center rounded-sm">
        <p className="text-2xl font-normal">Project List</p>
        <AdminSearchUserInput onSearch={setSearchTerm} />
        <div className="flex items-center gap-x-4">
          <p>Show Active Projects</p>
          <Switch
            checked={showActiveProjects}
            onCheckedChange={() => setShowActiveProjects((prev) => !prev)}
          />
        </div>
      </div>
      <Table className="px-16">
        <TableCaption>A list of Projects</TableCaption>
        <TableHeader className="text-gray-600 bg-gray-300 dark:bg-gray-700">
          <TableRow className="hover:bg-transparent">
            <TableHead className="w-10">No</TableHead>
            <TableHead className="w-10">code</TableHead>
            <TableHead>Project Name</TableHead>
            <TableHead>Starting Date</TableHead>
            <TableHead>Ending Date</TableHead>
            <TableHead>Project Manager</TableHead>
            <TableHead>Relationship Manager</TableHead>
            <TableHead>Status</TableHead>
            <TableHead className="text-right">Action</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody className="dark:bg-inherit">
          {filteredData.map((row, index) => (
            <TableRow key={row.id}>
              <TableCell className="font-medium">{index + 1}</TableCell>
              <TableCell className="font-medium">{row.projectCode}</TableCell>
              <TableCell>{row.name || "N/A"}</TableCell>
              <TableCell>
                {format(new Date(row.startDate), "dd/MM/yyyy")}
              </TableCell>
              <TableCell>
                {format(new Date(row.endDate), "dd/MM/yyyy")}
              </TableCell>
              <TableCell>{row.pmName}</TableCell>
              <TableCell>{row.rmName}</TableCell>
              <TableCell>
                <span
                  className={row.isActive ? "text-green-600" : "text-red-600"}
                >
                  {row.isActive ? "Active" : "Inactive"}
                </span>
              </TableCell>
              <TableCell className="text-right flex gap-x-2 justify-end">
                <Button
                  className="bg-red-500"
                  variant="default"
                  onClick={() => handleDeactivateProject(row.id)}
                  disabled={!row.isActive}
                >
                  Deactivate
                </Button>
                <Button
                  className="bg-blue-500"
                  variant="default"
                  onClick={() => handleEdit(row.id)}
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
