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
import { Switch } from "@/components/ui/switch";
import { Pencil, Trash2 } from "lucide-react";
import TooltipWrapper from "../tooltip-swrpper";
import { cn } from "@/lib/utils";
import { Skeleton } from "../ui/skeleton";

interface SupplierRow {
  id: number;
  name: string;
  pan: string;
  gst: string;
  tan: string;
  supplier_Code: string;
  isActive: boolean;
}

const AdminTableSupplier = () => {
  const router = useRouter();
  const [data, setData] = useState<SupplierRow[]>([]);
  const [searchTerm, setSearchTerm] = useState<string>("");
  const [showActiveSuppliers, setShowActiveSuppliers] = useState<boolean>(true);
  const [entriesPerPage, setEntriesPerPage] = useState<number>(5);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchSuppliers = async () => {
      try {
        const response = await api.get("/Supplier");
        setData(response.data);
      } catch (error) {
        console.error("Error fetching suppliers:", error);
      } finally {
        setLoading(false);
      }
    };
    fetchSuppliers();
  }, []);

  const handleEdit = (id: number) => {
    router.push(`/admin/manage-supplier/edit-supplier/${id}`);
  };

  const handleDeleteSupplier = async (id: number) => {
    setData((prevData) =>
      prevData.map((supplier) =>
        supplier.id === id ? { ...supplier, isActive: false } : supplier
      )
    );
    await api.patch("/Supplier", { id, isActive: false });
  };

  const filteredData = data.filter((row) => {
    const matchesSearch =
      row.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      row.tan.toLowerCase().includes(searchTerm.toLowerCase()) ||
      row.pan.toLowerCase().includes(searchTerm.toLowerCase()) ||
      row.gst.toLowerCase().includes(searchTerm.toLowerCase());

    const matchesActiveFilter = showActiveSuppliers ? row.isActive : !row.isActive;

    return matchesSearch && matchesActiveFilter;
  });

  return (
    <div className="rounded-lg overflow-hidden h-auto bg-white dark:bg-gray-900 pb-8 shadow-bottom">
      {/* Header Section */}
      <div className="p-6 flex flex-col sm:flex-row gap-4 justify-between items-start sm:items-center border-b border-gray-200 dark:border-gray-700">
        <h2 className="text-2xl font-semibold text-gray-800 dark:text-gray-100">
          Supplier Management
        </h2>
        <div className="flex items-center gap-2">
          <span className="text-sm text-gray-500 dark:text-gray-400">Show</span>
          <select
            className="border rounded px-2 py-1 text-sm dark:bg-gray-700 dark:border-gray-600 dark:text-gray-200"
            value={entriesPerPage}
            onChange={(e) => setEntriesPerPage(Number(e.target.value))}
          >
            <option>5</option>
            <option>10</option>
            <option>20</option>
          </select>
          <span className="text-sm text-gray-500 dark:text-gray-400">entries</span>
        </div>
        <div className="w-full sm:w-auto flex flex-col-reverse sm:flex-row gap-4 items-start sm:items-center">
          <AdminSearchUserInput onSearch={setSearchTerm} />
          <div className="flex items-center gap-3">
            <span className="text-sm text-gray-600 dark:text-gray-400">
              {showActiveSuppliers ? "Showing Active" : "Showing Inactive"}
            </span>
            <Switch
              checked={showActiveSuppliers}
              onCheckedChange={() => setShowActiveSuppliers((prev) => !prev)}
              className="data-[state=checked]:bg-blue-600 dark:data-[state=checked]:bg-blue-500"
            />
          </div>
        </div>
      </div>

      {/* Table Section */}
      <div className="relative overflow-x-auto">
        <Table className="min-w-full">
          <TableHeader className="sticky top-0 bg-gray-50/95 dark:bg-gray-900/95 backdrop-blur z-10">
            <TableRow className="border-b border-gray-200 dark:border-gray-700 hover:bg-transparent">
              <TableHead>No</TableHead>
              <TableHead>Code</TableHead>
              <TableHead>Supplier Name</TableHead>
              <TableHead>TAN</TableHead>
              <TableHead>PAN</TableHead>
              <TableHead>GST</TableHead>
              <TableHead>Status</TableHead>
              <TableHead className="text-right">Action</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {loading ? (
              Array(5)
                .fill(0)
                .map((_, index) => (
                  <TableRow
                    key={index}
                    className="border-b border-gray-200 dark:border-gray-700"
                  >
                    <TableCell>
                      <Skeleton className="h-4 w-6" />
                    </TableCell>
                    <TableCell>
                      <Skeleton className="h-4 w-32" />
                    </TableCell>
                    <TableCell>
                      <Skeleton className="h-4 w-24" />
                    </TableCell>
                    <TableCell>
                      <Skeleton className="h-4 w-24" />
                    </TableCell>
                    <TableCell>
                      <Skeleton className="h-4 w-40" />
                    </TableCell>
                    <TableCell>
                      <Skeleton className="h-4 w-48" />
                    </TableCell>
                    <TableCell>
                      <Skeleton className="h-4 w-16" />
                    </TableCell>
                    <TableCell className="flex justify-end gap-2">
                      <Skeleton className="h-8 w-8 rounded-md" />
                      <Skeleton className="h-8 w-8 rounded-md" />
                    </TableCell>
                  </TableRow>
                ))
            ) : filteredData.length === 0 ? (
              <TableRow>
                <TableCell
                  colSpan={8}
                  className="text-center py-12 text-gray-500 dark:text-gray-400"
                >
                  No suppliers found matching your criteria
                </TableCell>
              </TableRow>
            ) : (
              filteredData.slice(0, entriesPerPage).map((row, index) => (
                <TableRow
                  key={row.id}
                  className="border-b border-gray-200 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-800/50 transition-colors"
                >
                  <TableCell>{index + 1}</TableCell>
                  <TableCell>{row.supplier_Code}</TableCell>
                  <TableCell>{row.name}</TableCell>
                  <TableCell>{row.tan}</TableCell>
                  <TableCell>{row.pan}</TableCell>
                  <TableCell>{row.gst}</TableCell>
                  <TableCell className="shadow-right dark:shadow-dark-right">
                    <span
                      className={cn(
                        "inline-flex px-3 py-1 rounded-full text-xs font-medium",
                        row.isActive
                          ? "bg-green-100 text-green-800"
                          : "bg-red-100 text-red-800"
                      )}
                    >
                      {row.isActive ? "Active" : "Inactive"}
                    </span>
                  </TableCell>
                  <TableCell className="text-right flex gap-2 justify-end">
                    <TooltipWrapper content="Delete Supplier">
                      <Button
                        size="icon"
                        variant="ghost"
                        className="bg-blue-50 text-blue-600 dark:bg-blue-900/20 hover:bg-blue-100/50 dark:text-blue-400 dark:hover:bg-blue-900/30"
                        onClick={() => handleDeleteSupplier(row.id)}
                        disabled={!row.isActive}
                      >
                        <Trash2 className="h-4 w-4" />
                      </Button>
                    </TooltipWrapper>
                    <TooltipWrapper content="Edit Supplier">
                      <Button
                        size="icon"
                        variant="ghost"
                        className="bg-blue-50 text-blue-600 dark:bg-blue-900/20 hover:bg-blue-100/50 dark:text-blue-400 dark:hover:bg-blue-900/30"
                        onClick={() => handleEdit(row.id)}
                      >
                        <Pencil className="h-4 w-4" />
                      </Button>
                    </TooltipWrapper>
                  </TableCell>
                </TableRow>
              ))
            )}
          </TableBody>
        </Table>
      </div>
    </div>
  );
};

export default AdminTableSupplier;
