import AdminTableProject from '@/components/appComp/admin/admin-table-project'
import { Button } from '@/components/ui/button'
import Link from 'next/link'
import { Suspense } from 'react'

const ManageProject = () => {
  return (
    <div className='p-16'>
      <div className='flex justify-between items-center pb-6'>
         <h1 className='text-2xl font-medium text-primary-one'>Manage Project</h1>
         <Button className='px-4 dark:bg-blue-400' asChild>
          <Link href='/admin/manage-project/add-project'>Add Project</Link>
         </Button>
      </div>
      <Suspense fallback={<p>Loading Project table...</p>}>
      <AdminTableProject />
      </Suspense>
    </div>
  )
}

export default ManageProject