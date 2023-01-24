package es.fumpa.Centralita.repository;
import es.fumpa.Centralita.model.Departamento;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

@RepositoryRestResource(collectionResourceRel = "departamento", path = "departamento")
public interface DepartamentoRepository extends JpaRepository<Departamento, Integer> {

}
