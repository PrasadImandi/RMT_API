import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "../ui/dialog";
import { Button } from "../ui/button";
import api from "@/lib/axiosInstance";
import { useState } from "react";

interface DeleteProjectProps {
  id: string;
  type: string;
  onDelete: (id: string) => void;
  disabled: boolean // Function to handle delete in AdminTable
}

const DeleteProject = ({ id, onDelete, type, disabled }: DeleteProjectProps) => {
  const [isDialogOpen, setIsDialogOpen] = useState(false)
  const handleDelete = async () => {
    console.log(id);
    try {
      const endpoint = type === "resource" ? "/Resource" :
        type === "supplier" ? "/Supplier" : "/Project";

      if (type === "project") {
        const res = await api.patch(endpoint, {
          projectID: id,
          status: 'Inactive'
        });
      }
      else if (type === "resource") {
        const res = await api.patch(endpoint, {
          resourceID: id,
          status: 'Inactive'
        });
      }
      else if (type === "supplier") {
        const res = await api.patch(endpoint, {
          supplierID: id,
          status: 'Inactive'
        });
      }
      onDelete(id);
      setIsDialogOpen(false)
    } catch (error) {
      console.log("Error deleting user", error)
    }
  };
  return (
    <Dialog open={isDialogOpen} onOpenChange={setIsDialogOpen}>
      <DialogTrigger asChild>
        <Button className=" bg-blue-500" variant="default" disabled={disabled}>
          Inactive
        </Button>
      </DialogTrigger>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Are you absolutely sure?</DialogTitle>
          <DialogDescription>
            This will permanently delete the user
          </DialogDescription>
        </DialogHeader>
        <DialogFooter>
          <Button type="submit" onClick={handleDelete}>
            Inactive {type}
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
};

export default DeleteProject;
