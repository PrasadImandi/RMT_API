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
import { useRouter } from "next/navigation";
import api from "@/lib/axiosInstance";

interface UserRow {
    iD: string;
    name: string;
    description: string;
    email: string;
    accessTypeID: number;
    accessTypeName: string;
    isActive: boolean;
}

const AdminTableUser = () => {
    const router = useRouter();
    const [data, setData] = useState<UserRow[]>([]);
    const [searchTerm, setSearchTerm] = useState<string>("");

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const response = await api.get("/User"); // Replace with your API endpoint
                setData(response.data);
                console.log(response.data)
            } catch (error) {
                console.error("Error fetching users:", error);
            }
        };
        fetchUsers();
    }, []);

    const handleEdit = (id: string) => {
        router.push(`/admin/manage-user/edit-user/${id}`);
    };

    const handleDeactivateUser = (id: string) => {
        setData((prevData) =>
            prevData.map((user) =>
                user.iD === id ? { ...user, status: "Inactive" } : user
            )
        );
        console.log(`User with ID ${id} has been set to inactive.`);
    };

    const filteredData = data.filter(
        (row) =>
            row.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
            row.email.toLowerCase().includes(searchTerm.toLowerCase()) ||
            row.accessTypeName.toLowerCase().includes(searchTerm.toLowerCase())
    );

    if (data.length === 0) {
        return <p>Fetching data...</p>;
    }

    return (
        <>
            <div className="bg-white dark:bg-[#17171A] py-8 px-16 flex justify-between items-center rounded-sm">
                <p className="text-2xl font-normal">User List</p>
                <AdminSearchUserInput onSearch={setSearchTerm} />
            </div>
            <Table className="px-16">
                <TableCaption>A list of Users</TableCaption>
                <TableHeader className="text-gray-600 bg-gray-300 dark:bg-gray-700">
                    <TableRow className="hover:bg-transparent">
                        <TableHead className="w-10">No</TableHead>
                        <TableHead>Full Name</TableHead>
                        <TableHead>Email</TableHead>
                        <TableHead>Role</TableHead>
                        <TableHead className="text-right">Action</TableHead>
                    </TableRow>
                </TableHeader>
                <TableBody className="dark:bg-inherit dark:text-white">
                    {filteredData.map((row: UserRow, index) => (
                        <TableRow key={row.iD}>
                            <TableCell className="font-medium">{index + 1}</TableCell>
                            <TableCell>{row.name}</TableCell>
                            <TableCell>{row.email}</TableCell>
                            <TableCell>{row.accessTypeName}</TableCell>
                            <TableCell className="text-right flex gap-x-2 justify-end">
                                <Button
                                    className="bg-red-500"
                                    variant="default"
                                    onClick={() => handleDeactivateUser(row.iD)}
                                    disabled={row.isActive === false}
                                >
                                    Deactivate
                                </Button>
                                <Button
                                    className="bg-blue-500"
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

export default AdminTableUser;
